using AVtomirTestDB.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Dapper.Plus;

namespace AVtomirTestDB
{
    public class CbrDbContext
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["AvtomirTestDB"].ToString();
        public bool Save(BikData data)
        {

            Clear();

            // В этом варианте Упала производительность ) 
            //InsertSimple();

            Insert(data);

            return true;
        }

        private void Insert(BikData data)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                DapperPlusManager.Entity<BICDirectoryEntry>().Table("BICDirectoryEntry").Identity(x => x.Id);
                DapperPlusManager.Entity<ParticipantInfo>().Table("ParticipantInfo").Identity(x => x.Id);
                DapperPlusManager.Entity<Accounts>().Table("Accounts").Identity(x => x.Id);

                connection.BulkInsert(data.BICDirectoryEntry)
                    .Include(b => b.ThenForEach(x => x.ParticipantInfo.BICDirectoryEntryId = x.Id)
                    .ThenBulkInsert(x => x.ParticipantInfo))
                    .Include(a => a.ThenForEach(c => c.Accounts.ForEach(v => v.BICDirectoryEntryId = c.Id)).ThenBulkInsert(x => x.Accounts));
            }
        }

        private void Clear()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                //connection.Query("truncate table BICDirectoryEntry");
                //connection.Query("truncate table ParticipantInfo");
                //connection.Query("truncate table Accounts");
            }
        }

        
        
        private void InsertSimple(BikData data)
        {
            foreach (var item in data.BICDirectoryEntry)
            {
                int id = InsertBIC(item);
                InsertAccounts(id, item.Accounts);
                InsertParticipantInfo(id, item.ParticipantInfo);
            }
        }

        private int InsertBIC(BICDirectoryEntry item)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = @"insert into BICDirectoryEntry(BIC) values(@BIC); SELECT CAST(SCOPE_IDENTITY() as int)";
                int id = connection.Query<int>(sql, item).Single();
                return id;
            }
        }
        private void InsertAccounts(int id, List<Accounts> list)
        {
            list.ForEach(a => a.BICDirectoryEntryId = id);
            using (var connection = new SqlConnection(ConnectionString))
            {
                foreach (var item in list)
                {
                    string sql = @"insert into Accounts(Account, RegulationAccountType, CK, AccountCBRBIC, DateIn, AccountStatus, BICDirectoryEntryId) 
                                values(@Account, @RegulationAccountType, @CK, @AccountCBRBIC, @DateIn, @AccountStatus, @BICDirectoryEntryId)";
                    connection.Query(sql, item);
                }
            }
        }
        private void InsertParticipantInfo(int id, ParticipantInfo item)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                item.BICDirectoryEntryId = id;
                string sql = @"insert into ParticipantInfo(BICDirectoryEntryId, NameP, CntrCd, Rgn, Ind, Tnp, Nnp, Adr, DateIn, PtType, Srvcs, XchType, UID, ParticipantStatus, RegN)
                               values(@BICDirectoryEntryId, @NameP, @CntrCd, @Rgn, @Ind, @Tnp, @Nnp, @Adr, @DateIn, @PtType, @Srvcs, @XchType, @UID, @ParticipantStatus, @RegN)";
                connection.Query(sql, item);
            }
        }
    
    
    
    }
}
