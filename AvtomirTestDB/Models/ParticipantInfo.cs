using System.Xml.Serialization;

namespace AVtomirTestDB.Models
{
    [XmlRoot(ElementName = "ParticipantInfo", Namespace = "urn:cbr-ru:ed:v2.0")]
	public class ParticipantInfo
	{
		public long Id { get; set; }
		public long BICDirectoryEntryId { get; set; }

		[XmlAttribute(AttributeName = "NameP")]
		public string NameP { get; set; }
		[XmlAttribute(AttributeName = "CntrCd")]
		public string CntrCd { get; set; }
		[XmlAttribute(AttributeName = "Rgn")]
		public string Rgn { get; set; }
		[XmlAttribute(AttributeName = "Ind")]
		public string Ind { get; set; }
		[XmlAttribute(AttributeName = "Tnp")]
		public string Tnp { get; set; }
		[XmlAttribute(AttributeName = "Nnp")]
		public string Nnp { get; set; }
		[XmlAttribute(AttributeName = "Adr")]
		public string Adr { get; set; }
		[XmlAttribute(AttributeName = "DateIn")]
		public string DateIn { get; set; }
		[XmlAttribute(AttributeName = "PtType")]
		public string PtType { get; set; }
		[XmlAttribute(AttributeName = "Srvcs")]
		public string Srvcs { get; set; }
		[XmlAttribute(AttributeName = "XchType")]
		public string XchType { get; set; }
		[XmlAttribute(AttributeName = "UID")]
		public string UID { get; set; }
		[XmlAttribute(AttributeName = "ParticipantStatus")]
		public string ParticipantStatus { get; set; }

		[XmlAttribute(AttributeName = "RegN")]
		public string RegN { get; set; }
	}


}
