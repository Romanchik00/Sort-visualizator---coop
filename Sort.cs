using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sort
{
    public static class Sort
    {
        public static bool isLoop = true;

        public static void BubbleSort(ObservableCollection<double> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (!isLoop) { return; }
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
                    if (!isLoop) { return; }
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

        public static void InsertionSort(ObservableCollection<double> arr)
        {
            int n = arr.Count;
            for (int i = 1; i < n; i++)
            {
                double key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    if (!isLoop) { return; }
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public static void MergeSort(ObservableCollection<double> arr, int left, int right)
        {
            if (!isLoop) { return; }
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(ObservableCollection<double> arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            if (!isLoop) { return; }
            var L = new ObservableCollection<double>(new double[n1]);
            var R = new ObservableCollection<double>(new double[n2]);

            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, k = left;
            if (!isLoop) { return; }
            while (iIndex < n1 && jIndex < n2)
            {
                if (!isLoop) { return; }
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

        public static void QuickSort(ObservableCollection<double> arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                if (!isLoop) { return; }
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(ObservableCollection<double> arr, int low, int high)
        {
            double pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (!isLoop) { break; }
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
                    if (!Sort.isLoop) { return; }
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

        public static async void SelectionSort(ObservableCollection<double> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (!Sort.isLoop) { return; }
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                var temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
                await Task.Delay(150);
            }
        }

        public static async void InsertionSort(ObservableCollection<double> arr)
        {
            int n = arr.Count;
            for (int i = 1; i < n; i++)
            {
                double key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    if (!Sort.isLoop) { return; }
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
                await Task.Delay(150);
            }
        }

        public static void MergeSort(ObservableCollection<double> arr, int left, int right)
        {
            if (!Sort.isLoop) { return; }
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static async void Merge(ObservableCollection<double> arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            if (!Sort.isLoop) { return; }
            var L = new ObservableCollection<double>(new double[n1]);
            var R = new ObservableCollection<double>(new double[n2]);

            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, k = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (!Sort.isLoop) { return; }
                if (L[iIndex] <= R[jIndex])
                {
                    arr[k++] = L[iIndex++];
                }
                else
                {
                    arr[k++] = R[jIndex++];
                }
                await Task.Delay(25);
            }

            while (iIndex < n1)
            {
                if (!Sort.isLoop) { return; }
                arr[k++] = L[iIndex++];
                await Task.Delay(25);
            }

            while (jIndex < n2)
            {
                if (!Sort.isLoop) { return; }
                arr[k++] = R[jIndex++];
                await Task.Delay(25);
            }
        }

        public static async Task QuickSort(ObservableCollection<double> arr, int low, int high)
        {
            if (low < high)
            {
                int pi;
                pi = await Partition(arr, low, high);

                if (!Sort.isLoop) { return; }
                await QuickSort(arr, low, pi - 1);
                await QuickSort(arr, pi + 1, high);
            }
        }

        private static async Task<int> Partition(ObservableCollection<double> arr, int low, int high)
        {
            double pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (!Sort.isLoop) { break; }
                if (arr[j] < pivot)
                {
                    i++;
                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    await Task.Delay(100);
                }
            }
            var temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }


    }
}
