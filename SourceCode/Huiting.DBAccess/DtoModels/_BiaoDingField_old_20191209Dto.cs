using System;
using Newtonsoft.Json;
using Huiting.Contract.Attributes;
using XYY.Windows.SAAS.Contract.EntityInterfaces;

namespace Huiting.Contract.CMPModels
{
	[DataTable("_BiaoDingField_old_20191209")] 
	public class _BiaoDingField_old_20191209Dto
	{
		private String studytype;
		[JsonProperty("studytype")]
		[DataField("varchar",false,true)]
		public String StudyType
		{
			get
			{
				return studytype;
			}
			set
			{
				studytype = value;
			}
		}

		private String fieldcode;
		[JsonProperty("fieldcode")]
		[DataField("varchar",false,true)]
		public String FieldCode
		{
			get
			{
				return fieldcode;
			}
			set
			{
				fieldcode = value;
			}
		}

		private String fieldname;
		[JsonProperty("fieldname")]
		[DataField("varchar",false,false)]
		public String FieldName
		{
			get
			{
				return fieldname;
			}
			set
			{
				fieldname = value;
			}
		}

		private Int32 isdisplay;
		[JsonProperty("isdisplay")]
		[DataField("int",false,false)]
		public Int32 IsDisplay
		{
			get
			{
				return isdisplay;
			}
			set
			{
				isdisplay = value;
			}
		}

		private String fieldnote;
		[JsonProperty("fieldnote")]
		[DataField("varchar",false,false)]
		public String FieldNote
		{
			get
			{
				return fieldnote;
			}
			set
			{
				fieldnote = value;
			}
		}

		private Int32 fieldnum;
		[JsonProperty("fieldnum")]
		[DataField("int",false,false)]
		public Int32 FieldNum
		{
			get
			{
				return fieldnum;
			}
			set
			{
				fieldnum = value;
			}
		}

		private Int32 fieldtype;
		[JsonProperty("fieldtype")]
		[DataField("int",false,false)]
		public Int32 FieldType
		{
			get
			{
				return fieldtype;
			}
			set
			{
				fieldtype = value;
			}
		}

	}
}
