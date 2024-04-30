#!/bin/bash
gnome-terminal --tab -- bash -c "cd backend/StockViewer.Api; dotnet run; exec bash"
gnome-terminal --tab -- bash -c "cd frontend/StockViewer.Frontend; dotnet run; exec bash"
