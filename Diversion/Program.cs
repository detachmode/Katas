using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Diversion
{

    public class Diversion
    {
        public List<string> permutations;
        private readonly int bitcount;


        public Diversion(int bitcount)
        {
            this.bitcount = bitcount;
            this.permutations = new List<string>();
            PermutationProduced += PermutationConsumer;
        }


        //event Action<string> 


        public List<string> CreatePermutationIterative(int size)
        {
            List<string> workingList;

            workingList = CreateInitialList();

            ////var liste = ModifyList(workingList, iterations: 3, newList: x => x.Select(AddAusrufezeichen).ToList());
            //     workingList = ModifyList(workingList, iterations: size-1, newList: NextBiggerPermutations);


            Enumerable.Range(0, size - 1).ToList().ForEach(x =>
            {
                workingList = NextBiggerPermutations(workingList);
            });

            return workingList;
        }

        public List<string> CreatePermutationsBinary(int size)
        {
            var result = new List<string>();

            for (int i = 0; i < Math.Pow(2, size); i++)
            {
                string binary = Convert.ToString(i, toBase: 2).PadLeft(size, '0');
                result.Add(binary);
                //result.Add(binary.Substring(0, size));
            }

            return result;
        }

        private string AddAusrufezeichen(string y)
        {
            string str = "_";
            for (int i = 1; i <= y.Length; i++)
            {
                str += i.ToString();
            }
            str += "_";

            return y + str;
        }



        public List<string> NextBiggerPermutations(List<string> workingList)
        {
            var list1 = workingList.Select(x => x + "0").ToList();
            var list2 = workingList.Select(x => x + "1").ToList();

            list1.AddRange(list2);

            return list1;
        }

        private static List<string> CreateInitialList()
        {
            List<string> workingList = new List<string>() { "0", "1" };
            return workingList;
        }



        private void PermutationConsumer(string str, int stillMissing)
        {
            if (stillMissing == 0)
                permutations.Add(str);
            else
                createNextBiggerPermutation(str, stillMissing);
        }

        public int find_matching_combinations()
        {
            createPermutations();
            filteroutNotMatchingElements();

            return permutations.Count;
        }

        public void filteroutNotMatchingElements()
        {
            throw new NotImplementedException();
        }

        public void createPermutations()
        {
            createNextBiggerPermutation("", this.bitcount);
        }


        public void createNextBiggerPermutation(string str, int stillMissing)
        {
            PermutationProduced?.Invoke(str + "0", --stillMissing);
            PermutationProduced?.Invoke(str + "1", --stillMissing);
        }

        public event Action<string, int> PermutationProduced;

    }








    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
