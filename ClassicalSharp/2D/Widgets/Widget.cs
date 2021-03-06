﻿// ClassicalSharp copyright 2014-2016 UnknownShadow200 | Licensed under MIT
using System;
using System.Drawing;
using OpenTK.Input;

namespace ClassicalSharp.Gui.Widgets {	
	/// <summary> Represents an individual 2D gui component. </summary>
	public abstract class Widget : GuiElement {
		
		public Widget( Game game ) : base( game ) {
			HorizontalAnchor = Anchor.LeftOrTop;
			VerticalAnchor = Anchor.LeftOrTop;
		}
		
		/// <summary> Whether this widget is currently being moused over. </summary>
		public virtual bool Active { get; set; }
		
		/// <summary> Whether this widget is prevented from being interacted with. </summary>
		public virtual bool Disabled { get; set; }
		
		/// <summary> Invoked when this widget is clicked on. Can be null. </summary>
		public ClickHandler OnClick;
		
		/// <summary> Horizontal coordinate of top left corner in pixels. </summary>
		public int X;
		
		/// <summary> Vertical coordinate of top left corner in pixels. </summary>
		public int Y;
		
		/// <summary> Horizontal length of widget's bounds in pixels. </summary>
		public int Width;
		
		/// <summary> Vertical length of widget's bounds in pixels. </summary>
		public int Height;
		
		/// <summary> Specifies the horizontal reference point for when the widget is resized. </summary>
		public Anchor HorizontalAnchor;
		
		/// <summary> Specifies the vertical reference point for when the widget is resized. </summary>
		public Anchor VerticalAnchor;
		
		/// <summary> Horizontal offset from the reference point in pixels. </summary>
		public int XOffset = 0;
		
		/// <summary> Vertical offset from the reference point in pixels. </summary>
		public int YOffset = 0;
		
		/// <summary> Width and height of widget in pixels. </summary>
		public Size Size { get { return new Size( Width, Height ); } }
		
		/// <summary> Coordinate of top left corner of widget's bounds in pixels. </summary>
		public Point TopLeft { get { return new Point( X, Y ); } }
		
		/// <summary> Coordinate of bottom right corner of widget's bounds in pixels. </summary>
		public Point BottomRight { get { return new Point( X + Width, Y + Height ); } }
		
		/// <summary> Specifies the boundaries of the widget in pixels. </summary>
		public Rectangle Bounds { get { return new Rectangle( X, Y, Width, Height ); } }
		
		/// <summary> Moves the widget to the specified pixel coordinates. </summary>
		public virtual void MoveTo( int newX, int newY ) {
			X = newX; Y = newY;
		}
		
		public override void OnResize( int width, int height ) {
			int x = CalcOffset( width, Width, XOffset, HorizontalAnchor );
			int y = CalcOffset( height, Height, YOffset, VerticalAnchor );
			MoveTo( x, y );
		}
	}
}
