using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpfContentsViewer.collection;
using wpfContentsViewer.common;
using wpfContentsViewer.service;

namespace wpfContentsViewer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        RecordCollection records;
        ProgramCollection programs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RecordService recordService = new RecordService();

            records = new RecordCollection(recordService.GetAll());

            ProgramService programService = new ProgramService();

            programs = new ProgramCollection(programService.GetAll());

            dgridTvRecord.ItemsSource = records.collecion;
            dgridProgram.ItemsSource = programs.collecion;
        }

        private void OnTabButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void dgridTvRecord_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int COL_FILECOUNT = 0;
            int COL_EXTENSION = 1;
            int COL_NAME = 2;
            int COL_RATING = 3;
            //dgridTvRecord.Columns[COL_FILECOUNT].Width = 40;
            //dgridTvRecord.Columns[COL_EXTENSION].Width = 60;
            //dgridTvRecord.Columns[COL_RATING].Width = 70;

            //dgridTvRecord.Columns[COL_NAME].Width = CalcurateColumnWidth(dgridMovieContents);
        }

        private void OnButtonSearchClick(object sender, RoutedEventArgs e)
        {
            records.SetSearchText(txtSearch.Text);
            records.Execute();
        }

        private void txtSearchProgram_TextChanged(object sender, TextChangedEventArgs e)
        {
            programs.SetSearchText(txtSearchProgram.Text);
            programs.Execute();
        }
    }
}
