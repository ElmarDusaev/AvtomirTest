using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AVtomirTestDB.Models
{
	[Table("BikData")]
	[XmlRoot(ElementName = "ED807", Namespace = "urn:cbr-ru:ed:v2.0")]
	public class BikData
	{
		public long Id { get; set; }
		[XmlElement(ElementName = "BICDirectoryEntry", Namespace = "urn:cbr-ru:ed:v2.0")]
		public List<BICDirectoryEntry> BICDirectoryEntry { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }
		[XmlAttribute(AttributeName = "EDNo")]
		public string EDNo { get; set; }
		[XmlAttribute(AttributeName = "EDDate")]
		public string EDDate { get; set; }
		[XmlAttribute(AttributeName = "EDAuthor")]
		public string EDAuthor { get; set; }
		[XmlAttribute(AttributeName = "CreationReason")]
		public string CreationReason { get; set; }
		[XmlAttribute(AttributeName = "CreationDateTime")]
		public string CreationDateTime { get; set; }
		[XmlAttribute(AttributeName = "InfoTypeCode")]
		public string InfoTypeCode { get; set; }
		[XmlAttribute(AttributeName = "BusinessDay")]
		public string BusinessDay { get; set; }
		[XmlAttribute(AttributeName = "DirectoryVersion")]
		public string DirectoryVersion { get; set; }
	}


}
