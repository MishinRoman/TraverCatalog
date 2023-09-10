import React, { useEffect, useState } from "react";
import { IMedia, ITravel } from "../interfaces/app.interfaces";
import travelsService from "../services/travels.service";
import { key } from "localforage";
import GalereyList from "./GalereyList";
import mediasService from "../services/medias.service";
import { useQuery } from "@tanstack/react-query";

type Props = {
  travel: ITravel;
};
const cardWidth = 900;
const shortDate = (date: Date) => {
  return new Date(date).toLocaleDateString();
};
const shortTime = (date: Date) => {
  let housr: String = new Date(date).getHours().toString();
  let minutes: String = new Date(date).getMinutes().toString();
  return `${housr}:${minutes}`;
};

const TravelsCard = (props: Props) => {
  const [images, setImages] = useState<IMedia[]>();

  const { isLoading, isError, data, error } = useQuery(
    ["medias"],
    () => mediasService.GetMediaByTravelId(props.travel.id),
    {
      select: ({ data }) => data,

      onError(err) {
        return err;
      },

      //   staleTime:10,//время обновления данных
      //   cacheTime:10,//время х
    }
  );

  return (
    <div className="bg-slate-200 dark:bg-yellow-950 dark:text-white text-center m-4 p-4 rounded-md lg: w-{cardWidth}]">
      <GalereyList images={data} />

      <h3 className={"text-3xl m-4 p-4 overflow-x-hidden"}>
        {props.travel.description}
      </h3>
      <p>
        <span>Дата отправления: </span>
        {shortDate(props.travel.startDate)}
      </p>
      <p>
        <span>Время отправления: </span>
        {shortTime(props.travel.startDate)}
      </p>
      {}
    </div>
  );
};

export default TravelsCard;
