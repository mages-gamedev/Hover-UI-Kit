﻿using Hover.Renderers.Elements;
using Hover.Renderers.Elements.Shapes;
using Hover.Utils;
using UnityEngine;

namespace Hover.Renderers {

	/*================================================================================================*/
	[ExecuteInEditMode]
	[RequireComponent(typeof(TreeUpdater))]
	[RequireComponent(typeof(HoverShape))]
	public abstract class HoverFill : MonoBehaviour, ITreeUpdateable, ISettingsController {

		public ISettingsControllerMap Controllers { get; private set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected HoverFill() {
			Controllers = new SettingsControllerMap();
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public abstract int GetChildMeshCount();

		/*--------------------------------------------------------------------------------------------*/
		public abstract HoverMesh GetChildMesh(int pIndex);

		/*--------------------------------------------------------------------------------------------*/
		public HoverShape GetShape() {
			return gameObject.GetComponent<HoverShape>();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Start() {
			//do nothing...
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public virtual void TreeUpdate() {
			Controllers.TryExpireControllers();
		}
				
	}

}
