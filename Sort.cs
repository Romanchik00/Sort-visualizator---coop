using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public static class Sort
    {
        public static void BubbleSort(ObservableCollection<double> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(ObservableCollection<double> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                var temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        public static void InsertionSort(List<int> arr)
        {
            int n = arr.Count;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void MergeSort(List<int> arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(List<int> arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            var L = new List<int>(n1);
            var R = new List<int>(n2);

            for (int i = 0; i < n1; i++)
                L.Add(arr[left + i]);
            for (int j = 0; j < n2; j++)
                R.Add(arr[mid + 1 + j]);

            int iIndex = 0, jIndex = 0, k = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (L[iIndex] <= R[jIndex])
                {
                    arr[k++] = L[iIndex++];
                }
                else
                {
                    arr[k++] = R[jIndex++];
                }
            }

            while (iIndex < n1)
                arr[k++] = L[iIndex++];

            while (jIndex < n2)
                arr[k++] = R[jIndex++];
        }

        public static void QuickSort(List<int> arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(List<int> arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            var temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }
    }
    public static class VisualSort
    {
        public static async void BubbleSort(ObservableCollection<double> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        await Task.Delay(150);
                    }
                }
            }
        }

        //public static void SelectionSort(List<int> arr)
        //{
        //    int n = arr.Count;
        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        int minIndex = i;
        //        for (int j = i + 1; j < n; j++)
        //        {
        //            if (arr[j] < arr[minIndex])
        //            {
        //                minIndex = j;
        //            }
        //        }
        //        var temp = arr[i];
        //        arr[i] = arr[minIndex];
        //        arr[minIndex] = temp;
        //    }
        //}

        //public static void InsertionSort(List<int> arr)
        //{
        //    int n = arr.Count;
        //    for (int i = 1; i < n; i++)
        //    {
        //        int key = arr[i];
        //        int j = i - 1;
        //        while (j >= 0 && arr[j] > key)
        //        {
        //            arr[j + 1] = arr[j];
        //            j--;
        //        }
        //        arr[j + 1] = key;
        //    }
        //}

        //public static void MergeSort(List<int> arr, int left, int right)
        //{
        //    if (left < right)
        //    {
        //        int mid = left + (right - left) / 2;
        //        MergeSort(arr, left, mid);
        //        MergeSort(arr, mid + 1, right);
        //        Merge(arr, left, mid, right);
        //    }
        //}

        //private static void Merge(List<int> arr, int left, int mid, int right)
        //{
        //    int n1 = mid - left + 1;
        //    int n2 = right - mid;

        //    var L = new List<int>(n1);
        //    var R = new List<int>(n2);

        //    for (int i = 0; i < n1; i++)
        //        L.Add(arr[left + i]);
        //    for (int j = 0; j < n2; j++)
        //        R.Add(arr[mid + 1 + j]);

        //    int iIndex = 0, jIndex = 0, k = left;

        //    while (iIndex < n1 && jIndex < n2)
        //    {
        //        if (L[iIndex] <= R[jIndex])
        //        {
        //            arr[k++] = L[iIndex++];
        //        }
        //        else
        //        {
        //            arr[k++] = R[jIndex++];
        //        }
        //    }

        //    while (iIndex < n1)
        //        arr[k++] = L[iIndex++];

        //    while (jIndex < n2)
        //        arr[k++] = R[jIndex++];
        //}

        //public static void QuickSort(List<int> arr, int low, int high)
        //{
        //    if (low < high)
        //    {
        //        int pi = Partition(arr, low, high);
        //        QuickSort(arr, low, pi - 1);
        //        QuickSort(arr, pi + 1, high);
        //    }
        //}

        //private static int Partition(List<int> arr, int low, int high)
        //{
        //    int pivot = arr[high];
        //    int i = low - 1;

        //    for (int j = low; j < high; j++)
        //    {
        //        if (arr[j] < pivot)
        //        {
        //            i++;
        //            var temp = arr[i];
        //            arr[i] = arr[j];
        //            arr[j] = temp;
        //        }
        //    }
        //    var temp1 = arr[i + 1];
        //    arr[i + 1] = arr[high];
        //    arr[high] = temp1;
        //    return i + 1;
        //}
    }
}
