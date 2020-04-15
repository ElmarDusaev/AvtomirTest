using System.Xml.Serialization;

namespace AVtomirTestDB.Models
{
    [XmlRoot(ElementName = "Accounts", Namespace = "urn:cbr-ru:ed:v2.0")]
	public class Accounts
	{
		public long Id { get; set; }
		public long BICDirectoryEntryId { get; set; }

		[XmlAttribute(AttributeName = "Account")]
		public string Account { get; set; }
		[XmlAttribute(AttributeName = "RegulationAccountType")]
		public string RegulationAccountType { get; set; }
		[XmlAttribute(AttributeName = "CK")]
		public string CK { get; set; }
		[XmlAttribute(AttributeName = "AccountCBRBIC")]
		public string AccountCBRBIC { get; set; }
		[XmlAttribute(AttributeName = "DateIn")]
		public string DateIn { get; set; }
		[XmlAttribute(AttributeName = "AccountStatus")]
		public string AccountStatus { get; set; }

	}
}
