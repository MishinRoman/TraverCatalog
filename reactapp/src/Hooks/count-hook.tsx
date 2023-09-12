import { useLayoutEffect, useState } from "react";
import travelsService from "../services/travels.service";
import { useQueries, useQuery } from "@tanstack/react-query";



export const useCount=()=>{
  return  useQuery(
        ["count"],
        () =>travelsService.GetTravelsCount(),{
          select:({data})=>data,
          
          // staleTime:10,//время обновления данных
          // cacheTime:10,//время храниния данных
        }
        
      );
}