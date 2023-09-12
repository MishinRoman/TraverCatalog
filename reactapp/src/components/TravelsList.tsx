import { useQuery } from "@tanstack/react-query";
import React, { useCallback, useEffect, useState } from "react";
import travelsService from "../services/travels.service";
import { ITravel } from "../interfaces/app.interfaces";
import TravelsCard from "./TravelsCard";
import Loading from "./UI/loading";
import Pagination from "./Pagination";
import { useCount } from "../Hooks/count-hook";

type Props = {
 
};

const TravelsList = (props: Props) => {
  const [page, setPage] = useState(1);
  const count = useCount().data as number;
  //const [count, setCount] = useState(countData)
  
  

  

  const { isLoading, isError,  error, data,refetch } =
    useQuery(["travels", page], () => travelsService.GetTravelsPage(page), {
      select: ( {data} ) => data,
      keepPreviousData:false,

      onError(err) {
        return err;
      },
      //   staleTime:10,//время обновления данных
      //   cacheTime:10,//время х
    });
    
  const ROWS_PER_PAGE = 2;

  const getTotalPageCount = (rowCount: number): number => {
    
      return Math.ceil(rowCount / ROWS_PER_PAGE);
      };

  const handleNextPageClick = useCallback(() => {
    const current = page;
    const next = current + 1;
    const total = data ? getTotalPageCount(count) : current;

    setPage(next <= total ? next : current);
  }, [page, data]);

  const handlePrevPageClick = useCallback(() => {
    const current = page;
    const prev = current - 1;

    setPage(prev > 0 ? prev : current);
  }, [page]);

  return isError ? (
    <div>{(error as Error).message}</div>
  ) : (
    <>
   
      <div className="container flex pt-4 justify-center flex-wrap ">
        {isLoading ? (
          <div>
            <Loading />
            loading...
          </div>
        ) : (
          data?.map((d) => <TravelsCard key={d.id} travel={d} />).slice(0, ROWS_PER_PAGE)
        )}
      </div>
      <div className="flex items-center justify-between border-t border-gray-200 bg-white dark:bg-gray-900 dark:border-gray-800 px-4 py-3 sm:px-6 sticky bottom-0 m-auto">
     
        <Pagination
          disable={{
            left: page === 1,
            right: page === getTotalPageCount(count),
          }}
          nav={{
            current: page,
            total: getTotalPageCount(count),
          }}
          onNextPageClick={handleNextPageClick}
          onPrevPageClick={handlePrevPageClick}
        />
      </div>
    </>
  );
};

export default TravelsList;
