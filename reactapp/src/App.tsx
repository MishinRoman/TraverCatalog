import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import React from "react";
import TravelsList from "./components/TravelsList";
import { Link, NavLink, Route, Router } from "react-router-dom";
import NavBar from "./components/NavBar";

type Props = {};



const App = (props: Props) => {
  return (<div>
   
    <div className="container">
    Главная
      {/* <TravelsList /> */}
    

    </div>
  </div>
  );
};

export default App;
