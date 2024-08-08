﻿using Silk.NET.OpenGL;
using System;

namespace FrostyCliff.Graphics
{
    internal static class BufferWorker
    {

        private static unsafe void makeBuffers(ref uint vbo, ref uint vao, ref uint ebo, ref GL gl, float[] vertices, uint[] indices, bool texture = false)
        {
            vao = gl.GenVertexArray();
            gl.BindVertexArray(vao);

            vbo = gl.GenBuffer();
            gl.BindBuffer(BufferTargetARB.ArrayBuffer, vbo);

            fixed (float* buffer = vertices)
            {
                gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertices.Length * sizeof(float)), buffer, BufferUsageARB.StaticDraw);
            }

            ebo = gl.GenBuffer();
            gl.BindBuffer(BufferTargetARB.ElementArrayBuffer, ebo);

            fixed (uint* buffer = indices)
            {
                gl.BufferData(BufferTargetARB.ElementArrayBuffer, (nuint)(indices.Length * sizeof(uint)), buffer, BufferUsageARB.StaticDraw);
            }

            if (!texture)
            {
                gl.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), (void*)0);
                gl.EnableVertexAttribArray(0);
            }
            else
            {
                gl.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), (void*)0);
                gl.EnableVertexAttribArray(0);
                gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), (void*)(2 * sizeof(float)));
                gl.EnableVertexAttribArray(1);
            }

            gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
            gl.BindVertexArray(0);
        }

        internal static void RectangleBuffer(ref uint vbo, ref uint vao, ref uint ebo, ref GL gl)
        {
            float[] vertices =
            {
                0.5f,   0.5f,
                0.5f,  -0.5f,
                -0.5f, -0.5f,
                -0.5f,  0.5f,
            };

            uint[] indices =
            {
                0u, 1u, 3u,
                1u, 2u, 3u
            };

            makeBuffers(ref vbo, ref vao, ref ebo, ref gl, vertices, indices);
        }

        internal static void TriangleBuffer(ref uint vbo, ref uint vao, ref uint ebo, ref GL gl)
        {
            float[] vertices =
            {
                0.0f,   0.5f,
                -0.5f, -0.5f,
                0.5f,  -0.5f,
            };

            uint[] indices =
            {
                0u, 1u, 2u,
            };

            makeBuffers(ref vbo, ref vao, ref ebo, ref gl, vertices, indices);
        }

        internal static void SpriteBuffer(ref uint vbo, ref uint vao, ref uint ebo, ref GL gl)
        {
            float[] vertices = new float[]
            {
                // Position     //Texture position
                -0.5f, -0.5f,   0.0f, 1.0f,
                 0.5f, -0.5f,   1.0f, 1.0f,
                 0.5f,  0.5f,   1.0f, 0.0f,
                -0.5f,  0.5f,   0.0f, 0.0f
            };
            uint[] indices = new uint[]
            {
                0, 2, 1,
                0, 2, 3,
            };

            makeBuffers(ref vbo, ref vao, ref ebo, ref gl, vertices, indices, true);
        }

    }
}
