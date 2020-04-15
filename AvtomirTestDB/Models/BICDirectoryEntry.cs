using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVtomirTestDB.Models
{
    [XmlRoot(ElementName = "BICDirectoryEntry", Namespace = "urn:cbr-ru:ed:v2.0")]
	public class BICDirectoryEntry
	{
		public long Id { get; set; }
		[XmlElement(ElementName = "ParticipantInfo", Namespace = "urn:cbr-ru:ed:v2.0")]
		public ParticipantInfo ParticipantInfo { get; set; }
		[XmlElement(ElementName = "Accounts", Namespace = "urn:cbr-ru:ed:v2.0")]
		public List<Accounts> Accounts { get; set; }
		[XmlAttribute(AttributeName = "BIC")]
		public string BIC { get; set; }
	}
}
