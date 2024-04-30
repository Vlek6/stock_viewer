cd Frontend && doxygen Doxyfile && cd .. && cd backend && doxygen Doxyfile
start "" "%~dp0Frontend\docs\html\index.html"
start "" "%~Backend\docs\html\index.html"