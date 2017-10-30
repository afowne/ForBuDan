using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToolForDan
{
    public partial class MainWindow : Window
    {
        private void tabItem3_Initialized(object sender, EventArgs e)
        {
            var cfgHelper = new ConfigHelper();
            var temp = GameArea.GetSelectedGameAreas();
            if (temp.Count > 0)
            {
                Consts.LstServer.Except(temp).ToList().ForEach(p => listBox1.Items.Add(p));
                temp.ForEach(p => listBox2.Items.Add(p));
            }
            else
            {
                Consts.LstServer.ForEach(p => listBox1.Items.Add(p));
            }
            Reload();
        }

        private void btnReboot_Click(object sender, RoutedEventArgs e)
        {
            #region Obsolete
            //string strAppFileName = Process.GetCurrentProcess().MainModule.FileName;
            //Process myNewProcess = new Process();
            //myNewProcess.StartInfo.FileName = strAppFileName;
            //myNewProcess.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;

            //myNewProcess.Start();
            //Application.Current.Shutdown(); 
            #endregion
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void btnAddGameArea_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            listBox2.Items.Add(listBox1.SelectedItem);
            new GameArea().Add((listBox1.SelectedItem as GameArea).Code);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void btnRemoveGameArea_Click(object sender, RoutedEventArgs e)
        {
            if (listBox2.SelectedItem == null) return;

            listBox1.Items.Add(listBox2.SelectedItem);
            new GameArea((listBox2.SelectedItem as GameArea).Code).RemoveByCode();
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void btnAddSequence_Click(object sender, RoutedEventArgs e)
        {
            if (listBox2.SelectedItem == null) return;
            if (!HasSelected()) return;

            listBox3.Items.Add(listBox2.SelectedItem);

            new CustomSequence((dataGrid.SelectedItem as CustomSequence).CustomName).AddSequence((listBox2.SelectedItem as GameArea).Code);
        }

        private void btnRemoveSequence_Click(object sender, RoutedEventArgs e)
        {
            if (listBox3.SelectedItem == null) return;
            if (!HasSelected()) return;

            new CustomSequence((dataGrid.SelectedItem as CustomSequence).CustomName).RemoveSequence((listBox3.SelectedItem as GameArea).Code);
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void btnRemoveCustomSequence_Click(object sender, RoutedEventArgs e)
        {
            listBox3.Items.Clear();
            if (HasSelected())
            {
                new CustomSequence((dataGrid.SelectedItem as CustomSequence).CustomName).Remove();
            }
            Reload();
        }

        private void listBox3_Drop(object sender, DragEventArgs e)
        {
            var pos = e.GetPosition(listBox3);
            var result = VisualTreeHelper.HitTest(listBox3, pos);
            if (result == null)
            {
                return;
            }
            //查找元数据  
            var sourcePerson = e.Data.GetData(typeof(GameArea)) as GameArea;
            if (sourcePerson == null)
            {
                return;
            }
            //查找目标数据  
            var listBoxItem = FindVisualParent<ListBoxItem>(result.VisualHit);
            if (listBoxItem == null)
            {
                listBox3.Items.Remove(sourcePerson);
                listBox3.Items.Insert(listBox3.Items.Count, sourcePerson);
                return;
            }
            var targetPerson = listBoxItem.Content as GameArea;
            if (ReferenceEquals(targetPerson, sourcePerson))
            {
                return;
            }
            listBox3.Items.Remove(sourcePerson);
            listBox3.Items.Insert(listBox3.Items.IndexOf(targetPerson), sourcePerson);

            var l = listBox3.Items.Cast<GameArea>();// as IList<GameArea>;
            if (true)
            {
                var t = new CustomSequence((dataGrid.SelectedItem as CustomSequence).CustomName);
                t.RemoveSequence("", true);
                t.AddSequence(string.Join(",",l.Select(p=>p.Code).ToList()));
            }
        }

        public static T FindVisualParent<T>(DependencyObject obj) where T : class
        {
            while (obj != null)
            {
                if (obj is T)
                    return obj as T;

                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }

        private void listBox3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pos = e.GetPosition(listBox3);
                HitTestResult result = VisualTreeHelper.HitTest(listBox3, pos);
                if (result == null)
                {
                    return;
                }
                var listBoxItem = FindVisualParent<ListBoxItem>(result.VisualHit);
                if (listBoxItem == null || listBoxItem.Content != listBox3.SelectedItem)
                {
                    return;
                }
                DataObject dataObj = new DataObject(listBoxItem.Content as GameArea);
                DragDrop.DoDragDrop(listBox3, dataObj, DragDropEffects.Move);
            }
        }

        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    #region Ob
            //    UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
            //    if (elementWithFocus == null) return;
            //    e.Handled = true;

            //    if (dataGrid.CurrentCell.Column.DisplayIndex == dataGrid.Columns.Count - 1)
            //    {
            //        dataGrid.CommitEdit(DataGridEditingUnit.Row, exitEditingMode: true);
            //        elementWithFocus = Keyboard.FocusedElement as UIElement;
            //    }
            //    if (elementWithFocus != null)
            //    {
            //        elementWithFocus.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            //    } 
            //    #endregion

            //    var s = new CustomSequence();
            //    //s.Add(dataGrid.CurrentCell.Item.ToString())
            //}
        }

        private bool HasSelected()
        {
            //选择了编号，且编号栏不是新建栏且编号栏的区名不为空
            return dataGrid.SelectedItem != null
                && dataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}"
                && !string.IsNullOrEmpty((dataGrid.SelectedItem as CustomSequence).CustomName);
        }

        private void Reload()
        {
            dataGrid.ItemsSource = CustomSequence.GetAllCustomSequenceName();
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            listBox3.Items.Clear();
            if (HasSelected())
            {
                var currentCustomSequence = new CustomSequence((dataGrid.SelectedItem as CustomSequence).CustomName);
                currentCustomSequence.LoadAllSequence();
                if (currentCustomSequence.LstCodeSequence.Count > 0)
                {
                    int innerID = 0;
                    currentCustomSequence.LstCodeSequence.ForEach(p => {
                        var t = new GameArea();
                        t.ID=innerID;
                        t.Code=p.Code;
                        t.Name=p.Name;
                        listBox3.Items.Add(t);
                        innerID++;
                    });
                }
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = (e.EditingElement as TextBox).Text;
            if (string.IsNullOrEmpty(newValue))
            {
                MessageBox.Show("不能输出入空名");
            }
            else if ((dataGrid.ItemsSource as List<CustomSequence>).Exists(p => String.Equals(p.CustomName, newValue, StringComparison.InvariantCultureIgnoreCase)))
            {
                MessageBox.Show("已存在名为：" + newValue);
            }
            else
            {
                new CustomSequence().Add(newValue);
            }
            Reload();
        }
    }
}
