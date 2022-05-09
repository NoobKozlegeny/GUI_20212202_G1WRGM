using GUI_20212202_G1WRGM.AlmostLogic;
using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
using Models.SystemComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_G1WRGM.Renderer
{
    public class MapDisplay : FrameworkElement, IMapDisplay, ITickable
    {
        // Ez meg tulajdonképpen semmi mást nem csinálna csak az adott level nagyságáért felel xpixel*ypixel ++ esetleg alap hátteret állít az egészre meg ilyenek
        public IList<Map> Maps { get; set; }
        int currentLevel = 1;
        public bool DoRender { get; set; } = true;

        public void Resize(System.Drawing.Size size)
        {
            // Ez amúgy itt így nem lesz jó mert a map size != a képernyő méretével, ezért mondtam korábban, hogy 2 méret lesz a map-é meg a képernyőé
            // A képernyőé függ az ablakmérettől a map méretét pedig mi adjuk meg

            //this.size = size;
            //if (Maps != null)
            //{
            //    Maps.Size = size;
            //    this.InvalidateVisual();
            //}
        }

        public void SetupMap(IList<Map> maps)
        {
            this.Maps = maps;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            //base.OnRender(drawingContext);
            Map mapToDraw = Maps.FirstOrDefault(x => x.Level == currentLevel);
            // <ImageBrush x:Key="SimpleBitmap" ImageSource="Assets\BitmapImage.png" TileMode="FlipY"      Stretch="Uniform"AlignmentY="Top" Viewport="0,0,10,10" ViewportUnits="Absolute" />
            ImageBrush imageBrush = new ImageBrush(new BitmapImage(mapToDraw.PathToImg));
            imageBrush.TileMode = TileMode.Tile;
            imageBrush.Stretch = Stretch.Uniform;
            imageBrush.AlignmentY = AlignmentY.Top;
            imageBrush.Viewport = new Rect(0,0,2000,1096);
            imageBrush.ViewportUnits = BrushMappingMode.Absolute;
            
            drawingContext.DrawRectangle(
                    imageBrush,
                    new Pen(Brushes.Black, 0),
                    new Rect(new Size(mapToDraw.Size.Width, mapToDraw.Size.Height))
                );
        }

        public void TickProcess()
        {
            if (DoRender)
            {
                this.InvalidateVisual();
                DoRender = false;
            }

        }
    }
}
