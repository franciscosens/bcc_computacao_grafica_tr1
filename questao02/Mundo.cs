using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;
using FormasBiblioteca;
using System.Collections.Generic;
using Color = OpenTK.Color;

namespace questao02
{

    public class Mundo : GameWindow
    {
        public static Mundo instance = null;

        public Mundo(int width, int height) : base(width, height) { }

        public static Mundo getInstance()
        {
            if (instance == null)
                instance = new Mundo(600, 600);
            return instance;
        }

        private Camera camera = new Camera();
        protected List<Objeto> objetosLista = new List<Objeto>();
        private bool moverPto = false;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // GerarLinhas();
            double raio = 100;

            var segmentoRetaA = new SegReta("A", new Ponto4D(0, 0, 0), new Ponto4D(200, 0, 0), Color.Red, 5);
            var segmentoRetaB = new SegReta("B", new Ponto4D(0, 0, 0), new Ponto4D(0, 200, 0), Color.Green, 5);
            var circuloA = new Circulo("A", raio, Color.Yellow, 0, 0, 5);

            objetosLista.Add(segmentoRetaA);
            objetosLista.Add(segmentoRetaB);
            objetosLista.Add(circuloA);
            GL.ClearColor(Color.Gray);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
            GL.Ortho(-300, 300, -300, 300, -1, 1);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            for (var i = 0; i < objetosLista.Count; i++)
            {
                objetosLista[i].Desenhar();
            }

            this.SwapBuffers();
        }

        private void GerarLinhas()
        {
            GL.LineWidth(5);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex2(0, 0); GL.Vertex2(200, 0);
            GL.Color3(Color.Green);
            GL.Vertex2(0, 0); GL.Vertex2(0, 200);
            GL.End();
        }


        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Exit();
            else
            if (e.Key == Key.E)
            {
                for (var i = 0; i < objetosLista.Count; i++)
                {
                    objetosLista[i].PontosExibirObjeto();
                }
            }
            else
            if (e.Key == Key.M)
            {
                moverPto = !moverPto;
            }
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            if (moverPto)
            {
                //retanguloB.MoverPtoSupDir(new Ponto4D(e.Position.X, 600 - e.Position.Y, 0));
            }
        }
    }
}