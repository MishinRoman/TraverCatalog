import React, { useState } from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import AdminPanel from "./components/AdminPanel.js";
import TravelsList from "./components/TravelsList.js";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import NavBar from "./components/NavBar.js";
import travelsService from "./services/travels.service.js";


const queryClient = new QueryClient();

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/admin",
    element: <AdminPanel />,
  },
  {
    path: "/travels",

    element: <TravelsList  />,
  },
]);


ReactDOM.createRoot(document.getElementById("root") as HTMLElement, ).render(
  <React.StrictMode>
    <QueryClientProvider client={queryClient}>
    <NavBar/>
      <RouterProvider router={router} />
    </QueryClientProvider>
  </React.StrictMode>
);
