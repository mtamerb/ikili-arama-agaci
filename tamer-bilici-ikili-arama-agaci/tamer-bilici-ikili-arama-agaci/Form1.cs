using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tamer_bilici_ikili_arama_agaci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // agaca ekleme  silme  listeleme  opr.

        public BST root;

        public class BST
        {
            public int data;
            public BST right;
            public BST left;
        }

        void insert(int key)
        {
            BST newNode = new BST();
            newNode.data = key;

            if (root == null)
            {
                root = newNode;
                label2.Text = Convert.ToString(key + " eklendi");
            }
            else
            {
                BST temp = root;
                BST top;
                while (true)
                {
                    top = temp;
                    if (key < temp.data)
                    {
                        temp = temp.left;
                        if (temp == null)
                        {
                            top.left = newNode;
                            label2.Text = Convert.ToString(key + " eklendi");
                            return;
                        }

                    }
                    else
                    {
                        temp = temp.right;
                        if (temp == null)
                        {
                            top.right = newNode;
                            label2.Text = Convert.ToString(key + " eklendi");
                            return;
                        }

                    }
                }
            }
        }


         void showNodes(BST node)
         {

             if (root != null)
             
                 txtbox_show.Text = "root ->  " + Convert.ToString(node.data) + Environment.NewLine;
             

             if (node.left != null)
             {
                 txtbox_show.Text += "left -> " + Convert.ToString(node.left.data) + Environment.NewLine;
                 showLow(node.left, "left -> ");
             }

             if (node.right != null)
             {
                 txtbox_show.Text += "right -> " + Convert.ToString(node.right.data) + Environment.NewLine;
                 showLow(node.right, "right -> ");
             }

         }

         void showLow(BST node, string pointer) {

             if (node.left != null)
             {
                 txtbox_show.Text += pointer + "left -> " + Convert.ToString(node.left.data) + Environment.NewLine;
                 pointer += "left -> ";
                 showLow(node.left, pointer);
             }
             if (node.right != null)
             {
                 txtbox_show.Text += pointer + "rigth -> " + Convert.ToString(node.right.data) + Environment.NewLine;
                 pointer += "right -> ";
                 showLow(node.right, pointer);
             }

         }


         public BST deleteNode(BST root, int key)
         {
             if (root == null)
             {
                 return null;
             }

             if (key < root.data)
             {
                 root.left = deleteNode(root.left, key); 
             }
             if (key > root.data)
             {
                 root.right = deleteNode(root.right, key);
             }

             if (root.left != null && root.right != null)
             {
                 root.data = Max(root.left).data;
                 root.left = deleteNode(root.left, root.data);
             }
             if (root.left != null)
             {
                 root = root.left;
             }
             else
             {
                 root = root.right;
             }
             return root;
         }

         public BST Max(BST root)
         {
             if (root == null)
             {
                 return null;
             }
             BST temp = root;
             while (temp.right != null)
             {
                 temp = temp.right;
             }

             return temp;

         }

         public BST find(BST root, int key)
         {

             if (root == null)
             {
                 MessageBox.Show("can not found");
                 return null;
             }

             else
             {
                 if (key == root.data)
                 {
                     MessageBox.Show("its found");
                 }

                 if (key < root.data)
                 {
                     return find(root.left, key);
                 }
                 if (key > root.data)
                 {
                     return find(root.right, key);
                 }

             }

             return root;

         }


        // bilgiler 

         public int numberOfNode(BST node)
         {
             int size = 0;
             if (node != null)
             {
                 size = 1;
                 size += numberOfNode(node.right);
                 size += numberOfNode(node.left);
             }
             return size;
         }

         public int height(BST root)
         {
             if (root == null)
             {
                 return 0;
             }

             return Math.Max(height(root.left), height(root.right)) + 1;
         }


         public int leaf(BST node)
         {
             if (node == null)
             {
                 return 0;
;
             }
             if (node.left == null && node.right == null)
             {
                 return 1;
             }
             return leaf(node.left) + leaf(node.right);
         }


        // ın or post _ order


        
         void postorder(BST root)
         {
             if (root == null)
             {
                 return;
             }
             postorder(root.left);
             postorder(root.right);
             textBox7.Text += root.data + " ";

         }

         void preorder(BST root)
         {
             if (root == null)
             {
                 return;
             }

             textBox5.Text += root.data + " "; 
             preorder(root.left);
             preorder(root.right);
          
         }
         void inorder(BST root)
         {
             if (root == null)
             {
                 return;
             }

             inorder(root.left);
             textBox6.Text += root.data + " ";
             inorder(root.right);
             

         }






        private void btn_ekle_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(txtbox_ekle.Text);
            insert(key);
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            txtbox_show.Text = " ";
            showNodes(root);
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int data = Convert.ToInt32(txtbox_sil.Text);
            deleteNode(root, data);
            label3.Text = Convert.ToString(data + " silindi ");
        }

        private void btn_bul_Click(object sender, EventArgs e)
        {
            int data = Convert.ToInt32(txtbox_bul.Text);
            find(root, data);
        }

        private void btn_bilgi_goster_Click(object sender, EventArgs e)
        {


            preorder(root);
            inorder(root);
            postorder(root);


            textBox8.Text = Convert.ToString(numberOfNode(root));
            textBox9.Text = Convert.ToString(height(root) - 1);
            textBox10.Text = Convert.ToString(leaf(root));
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }










    }
}
