using System;
using DevExpress.Xpo;

namespace QLDSV { 
	
	public class undoRedo : XPObject {
		public undoRedo() : base() {
			// This constructor is used when an object is loaded from a persistent storage.
			// Do not place any code here.
		}

		public undoRedo(Session session) : base(session) {
			// This constructor is used when an object is loaded from a persistent storage.
			// Do not place any code here.
		}

		public override void AfterConstruction() { 
			base.AfterConstruction(); 
			// Place here your initialization code.
		}
	}

}