using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace CleanCode.Examples
{
    public class Example10
    {
        public void DoSomething()
        {
            var ls = new List<List<Tuple<Terminal, int>>>();
            var cl = new List<Tuple<Terminal, int>>();
            for (int i = 0; i < Template.Terminals.Count; i++)
            {
                var term = Template.Terminals[i];
                var s = term.Text;
                if (s.Count(c => c == '\n' || c == '\r') > 0)
                {
                    var arr = s.Split('\n', '\r');
                    for (var j = 0; j < arr.Length - 1; j++)
                    {
                        if (arr[j].Length == 0) arr[j] = " ";
                        cl.Add(Tuple.Create(new Terminal(arr[j], term), i));
                        ls.Add(cl);
                        cl = new List<Tuple<Terminal, int>>();
                    }
                    s = arr[arr.Length - 1];
                }
                cl.Add(Tuple.Create(new Terminal(s, term), i));
            }
            ls.Add(cl);

            var h = 0d;
            var renderLine = new List<Tuple<double, int, Terminal>>();
            var flag = false;
            foreach (var l in ls)
            {
                renderLine = new List<Tuple<double, int, Terminal>>();
                var w = 0d;
                var lineH = 0d;
                foreach (var term in l)
                {
                    var ft = new FormattedText(term.Item1.Text, CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight, new Typeface("Verdana"), 10, Brushes.Black);
                    ft.Set(term.Item1);
                    lineH = Math.Max(lineH, ft.Height);
                    w += ft.WidthIncludingTrailingWhitespace;
                    renderLine.Add(Tuple.Create(w, term.Item2, term.Item1));
                }
                h += lineH;
                if (p.Y < h) { flag = true; break; }
            }
            pp = p;
            InvalidateVisual();
            if (!flag)
                return;
            flag = false;
            Tuple<double, int, Terminal> ct = null;
            foreach (var d in renderLine)
                if (d.Item1 > p.X)
                {
                    flag = true;
                    ct = d;
                    Debug.WriteLine(d.Item2);
                    _sTermEnd = _sTermStart = d.Item2;
                    break;
                }
            if (!flag)
                return;
            var ft1 = new FormattedText(ct.Item3.Text, CultureInfo.CurrentCulture,
                 FlowDirection.LeftToRight, new Typeface("Verdana"), 10, Brushes.Black);
            ft1.Set(ct.Item3);
            var sw = ct.Item1 - ft1.WidthIncludingTrailingWhitespace;
            for (int i = 0; i < ct.Item3.Text.Length; i++)
            {
                var ch = ct.Item3.Text[i];
                var ft2 = new FormattedText(ch.ToString(), CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface("Verdana"), 10, Brushes.Black);
                ft2.Set(ct.Item3);
                sw += ft2.WidthIncludingTrailingWhitespace;
                if (sw > p.X)
                {
                    Debug.WriteLine(i);
                    _sOffEnd = _sOffStart = i;
                    break;
                }
            }
        }

        private Template Template { get; set; }
    }
}
