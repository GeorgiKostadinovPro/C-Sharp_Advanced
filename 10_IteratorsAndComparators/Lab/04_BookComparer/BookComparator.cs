﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            int result = x.Title.CompareTo(y.Title);

            if (result == 0)
            {
                if (x.Year > y.Year)
                {
                    return -1;
                }
                else if (x.Year < y.Year)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return result;
        }
    }
}
