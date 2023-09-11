import { useQuery } from "@tanstack/react-query";
import React, { useState } from "react";
import travelsService from "../services/travels.service";
import { ITravel } from "../interfaces/app.interfaces";
import TravelsCard from "./TravelsCard";
import Loading from "./UI/loading";


type Props = {};

const TravelsList = (props: Props) => {
  const { isLoading, isError, data, error } = useQuery(
    ["travels"],
    () => travelsService.GetTravels(),
    {
      select: ({ data }) => data,

      onError(err) {
        return err;
      },

      //   staleTime:10,//время обновления данных
      //   cacheTime:10,//время х
    }
  );

  return isError ? (
    <div>{(error as Error).message}</div>
  ) : (
    <div className="container flex pt-4 justify-center flex-wrap">
      {isLoading ? (
        <div>
         <Loading/>
          loading...
        </div>
      ) : (
        data?.map((d) => <TravelsCard key={d.id} travel={d} />)
      )}
    </div>
  );
};

export default TravelsList;
