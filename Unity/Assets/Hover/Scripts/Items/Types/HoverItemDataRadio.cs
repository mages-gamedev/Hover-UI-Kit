﻿using System;
using UnityEngine;

namespace Hover.Items.Types {

	/*================================================================================================*/
	[Serializable]
	public class HoverItemDataRadio : SelectableItemBool, IRadioItem {
		
		[SerializeField]
		private string _DefaultGroupId;

		[SerializeField]
		private string _GroupId;
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void InitDefaultGroupId(Transform pParentTx) {
			if ( pParentTx == null ) {
				_DefaultGroupId = "Group-Root";
				return;
			}

			HoverItemData parentData = pParentTx.GetComponent<HoverItemData>();

			if ( parentData != null ) {
				_DefaultGroupId = "Group-"+parentData.AutoId;
				return;
			}

			_DefaultGroupId = "Group-Instance"+pParentTx.GetInstanceID();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public string DefaultGroupId {
			get { return _DefaultGroupId; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public string GroupId {
			get {
				return (string.IsNullOrEmpty(_GroupId) ? _DefaultGroupId : _GroupId);
			}
			set {
				_GroupId = value;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Select() {
			Value = true;
			base.Select();
		}

		/*--------------------------------------------------------------------------------------------*/
		public override bool AllowSelection {
			get {
				return (!Value && base.AllowSelection);
			}
		}

	}

}
