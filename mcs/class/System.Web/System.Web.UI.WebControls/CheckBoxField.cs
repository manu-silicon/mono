//
// System.Web.UI.WebControls.CheckBoxField.cs
//
// Authors:
//	Lluis Sanchez Gual (lluis@novell.com)
//
// (C) 2005 Novell, Inc (http://www.novell.com)
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if NET_2_0
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.ComponentModel;
using System.Security.Permissions;

namespace System.Web.UI.WebControls {

	[AspNetHostingPermissionAttribute (SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermissionAttribute (SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class CheckBoxField : BoundField
	{
		public override bool ConvertEmptyStringToNull {
			get { throw GetNotSupportedPropException ("ConvertEmptyStringToNull"); } 
			set { throw GetNotSupportedPropException ("ConvertEmptyStringToNull"); } 
		}
		
		public override string DataFormatString {
			get { throw GetNotSupportedPropException ("DataFormatString"); } 
			set { throw GetNotSupportedPropException ("DataFormatString"); } 
		}
		
		public override bool HtmlEncode {
			get { throw GetNotSupportedPropException ("HtmlEncode"); } 
			set { throw GetNotSupportedPropException ("HtmlEncode"); } 
		}
		
		public override string NullDisplayText {
			get { throw GetNotSupportedPropException ("NullDisplayText"); } 
			set { throw GetNotSupportedPropException ("NullDisplayText"); } 
		}
		
		protected override bool SupportsHtmlEncode {
			get { return false; }
		}
		
	    [WebCategoryAttribute ("Appearance")]
	    [LocalizableAttribute (true)]
	    [DefaultValueAttribute ("")]
		public virtual string Text {
			get {
				object ob = ViewState ["Text"];
				if (ob != null) return (string) ob;
				return "";
			}
			set {
				ViewState ["Text"] = value;
				OnFieldChanged ();
			}
		}
		
		public override void InitializeDataCell (DataControlFieldCell cell, DataControlRowState rowState)
		{
			bool editable = (rowState & DataControlRowState.Edit) != 0;
			CheckBox box = new CheckBox ();
			box.Enabled = editable && !ReadOnly;
			cell.Controls.Add (box);
		}
		
		public override void ExtractValuesFromCell (IOrderedDictionary dictionary,
			DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
		{
			CheckBox box = (CheckBox) cell.Controls [0];
			dictionary [DataField] = box.Checked;
		}
		
		protected override void OnDataBindField (object sender, EventArgs e)
		{
			DataControlFieldCell cell = (DataControlFieldCell) sender;
			CheckBox box = (CheckBox) cell.Controls [0];
			object val = GetValue (cell.BindingContainer);
			if (val != null) {
				box.Checked = (bool)val;
				if (!box.Visible)
					box.Visible = true;
			}
			else
				box.Visible = false;
		}
		
		protected override object GetDesignTimeValue ()
		{
			return true;
		}
	}
}
#endif
