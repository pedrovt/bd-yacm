using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace YACM
{

	public enum DocumentType
	{
		Text, Other
	}

	[Serializable()]
	public class Document
	{
		public int ID { get; set; }
		public int EventID { get; set; }
		public DocumentType Type { get; set; }
		public String Path { get; set; }
		public String Contents { get; set; }

		public override String ToString() {
			return "Document " + Id + " type  " + Type;
		}

		public Document() : base() {
		}

		public Document(int id, DocumentType type, String pathOrContents) : base() {
			this.Id = id;
			Type = type;
			switch (type) {
				case DocumentType.Text:
					Contents = pathOrContents;
					Path = "";
					break;
				case DocumentType.Other:
					Path = pathOrContents;
					Contents = "";
					break;
			}
		}
	}
}

