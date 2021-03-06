﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiB
{
    class BinaryTreeNode
    {
        String content;
        BinaryTreeNode left;
        BinaryTreeNode right;
        Boolean visited;
        Boolean solved;
        int id;
        int line;

        internal BinaryTreeNode Right { get { return right; } set { right = value; } }
        internal BinaryTreeNode Left { get { return left; } set { left = value; } }
        public string Content { get { return content; } set { content = value; } }
        public bool Visited { get { return visited; } set { visited = value; } }
        public int Id { get { return id; } set { id = value; } }
        public bool Solved { get { return solved; } set { solved = value; } }
        public int Line { get { return line; } set { line = value; } }

        public BinaryTreeNode(String content, int line)
        {
            Content = content;
            Visited = false;
            Id = 0;
            line = -1;
        }
        public BinaryTreeNode(Token t)
        {
            Content = t.Val;
            Visited = false;
            Id = 0;
            line = t.NLinea;
        }

        public BinaryTreeNode(String content, BinaryTreeNode left, BinaryTreeNode right)
        {
            Content = content;
            Left = left;
            Right = right;
            Visited = false;
            Id = 0;
            line = -1;
        }

        public BinaryTreeNode(Token t, BinaryTreeNode left, BinaryTreeNode right)
        {
            Content = t.Val;
            Left = left;
            Right = right;
            Visited = false;
            Id = 0;
            line = t.NLinea;
        }
    }
}