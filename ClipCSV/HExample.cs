﻿namespace ClipCSV
{
    static class HExample
    {
        static public string Get1()
        {
            var h = new[] 
            {
                "<html>",
                "<head>",
                "<meta name=\"DESCRIPTION\"",
                "content=\"This is the homepage of Bjarne Stroustrup,",
                "the designer and original implementor of C++\">",
                "<meta name=\"KEYWORDS\"",
                "content=\"The C++ Programming Language,Bjarne Stroustrup,C++,homepage,books,",
                "papers,biography\">",
                "<title>Bjarne Stroustrup's Homepage</title>",
                "<style>",
                "div.day {",
                "	padding:0.5em;",
                "	border-style:solid;",
                "	border-width:2px;",
                "	background-color:rgb(252,221,163);",
                "	width:250px;",
                "	float:right",
                "}",
                "</style>",
                "</head>",
                "<body bgcolor=\"FFFBFB\">",
                "<--Start Fragment-->",          // marker
                "<center>",
                "<a href=\"http://www.morganstanley.com/\">Morgan Stanley</a>",
                "<a href=\"http://www.cs.columbia.edu/\">Columbia University</a>",
                "<a href=\"https://www.chu.cam.ac.uk/\">Churchill College, Cambridge</a>",
                "</a>",
                "</center>",
                "<p>",
                "<center>",
                "<a href=\"index.html\">home</a>",
                "<a href=\"C++.html\">C++</a>",
                "<a href=\"bs_faq.html\">FAQ</a>",
                "<a href=\"bs_faq2.html\">technical FAQ</a>",
                "<a href=\"papers.html\">publications</a>",
                "<a href=\"WG21.html\">WG21 papers</a>",
                "<a href=\"4th.html\">TC++PL</a>",
                "<a href=\"tour2.html\">Tour++</a>",
                "<a href=\"programming.html\">Programming</a>",
                "<a href=\"dne.html\">D&E</a>",
                "<a href=\"bio.html\">bio</a>",
                "<a href=\"interviews.html\">interviews</a>",
                "<a href=\"videos.html\">videos</a>",
                "<a href=\"applications.html\">applications</a>",
                "<a href=\"https://github.com/isocpp/CppCoreGuidelines/blob/master/CppCoreGuidelines.md\">guidelines</a>",
                "<a href=\"compilers.html\">compilers</a>",
                "</center>",
                "<center>",
                "<h1>Welcome to Bjarne Stroustrup's homepage!</h1>",
                "<img src=\"Bjarne2018.jpg\"\">",
                "</center>",
                "<p>",
                "I'm a Technical Fellow and a Managing Director in the technology division of",
                "<a href=\"http://www.morganstanley.com/\">Morgan Stanley</a>",
                "in New York City",
                "and a Visiting Professor in Computer Science at",
                "<a href=\"http://www.cs.columbia.edu/\">Columbia University</a>.",
                "<p>",
                "I designed and implemented",
                "<a href=\"C++.html\"> the C++ programming language</a>.",
                "To make C++ a stable and up-to-date base for real-world software development, I have stuck with its ISO standards effort for almost 30 years (so far).",
                "<p>",
                "<ul>",
                "<li>",
                "<a href=\"tour2.html\">A Tour of C++ (2nd edition)</a> (a brief - 240 page - tour of the C++ Programming language and its standard library for experienced programmers)",
                "<li>",
                "<a href=\"4th.html\">The C++ Programming Language (4th edition)</a> (an exhaustive description of the C++ Programming language, its standard library, and fundamental techniques for experienced programmers)",
                "<li>",
                "<a href=\"programming.html\">Programming: Principles and Practice using C++ (2nd edition)</a> (a programming text book aimed at beginners who want eventually to become professionals)",
                "<li>",
                "<a href=\"dne.html\">The Design and Evolution of C++</a> (a book presenting the rationale and design criteria for C++ and its evolution up until 1994).",
                "<li>",
                "<a href=\"papers.html\">Research and popular papers</a>",
                "<li>",
                "<a href=\"WG21.html\">Technical reports and proposals for the ISO C++ Standard</a>",
                "<li>",
                "<a href=\"videos.html\">Videos</a>",
                "<li>",
                "<a href=\"interviews.html\">Interviews</a>",
                "<li>",
                "<a href=\"bio.html\">Biographical material</a>,",
                "</ul>",
                "<p>",
                "<center>",
                "<a href=\"http://www.morganstanley.com/\">Morgan Stanley</a>",
                "<a href=\"http://www.cs.columbia.edu/\">Columbia University</a>",
                "<a href=\"https://www.chu.cam.ac.uk/\">Churchill College, Cambridge</a>",
                "</a>",
                "</center>",
                "<p>",
                "<center>",
                "<a href=\"index.html\">home</a>",
                "<a href=\"C++.html\">C++</a>",
                "<a href=\"bs_faq.html\">FAQ</a>",
                "<a href=\"bs_faq2.html\">technical FAQ</a>",
                "<a href=\"papers.html\">publications</a>",
                "<a href=\"WG21.html\">WG21 papers</a>",
                "<a href=\"4th.html\">TC++PL</a>",
                "<a href=\"tour2.html\">Tour++</a>",
                "<a href=\"programming.html\">Programming</a>",
                "<a href=\"dne.html\">D&E</a>",
                "<a href=\"bio.html\">bio</a>",
                "<a href=\"interviews.html\">interviews</a>",
                "<a href=\"videos.html\">videos</a>",
                "<a href=\"applications.html\">applications</a>",
                "<a href=\"https://github.com/isocpp/CppCoreGuidelines/blob/master/CppCoreGuidelines.md\">guidelines</a>",
                "<a href=\"compilers.html\">compilers</a>",
                "</center>",
                "<--End Fragment-->",          // marker
                "</body>",
                "</html>",
                "",
            };
            return string.Join("\r\n", h);
        }
    }
}