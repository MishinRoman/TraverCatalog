import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import React from "react";
import TravelsList from "./components/TravelsList";
import { Link, NavLink, Route, Router } from "react-router-dom";
import NavBar from "./components/NavBar";

type Props = {};

const App = (props: Props) => {
  return (
    <div>
      <div className="wrapper bg-image p-20 h-screen">
        <h1 className="travel_slong text-4xl p-6">
          Путешествуйте по стране с нами
        </h1>
        <h2 className="slong">Расширяем горизонты в рамках границ.</h2>
      </div>
    </div>
  );
};

export default App;
