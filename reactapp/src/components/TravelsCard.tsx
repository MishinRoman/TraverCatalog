import React, { useState } from "react";
import { IMedia, ITravel } from "../interfaces/app.interfaces";
import travelsService from "../services/travels.service";
import { key } from "localforage";
import GalereyList from "./GalereyList";


type Props = {
  travel: ITravel;
};
const cardWidth = 900;
const shortDate =(date:Date)=>{
    return new Date(date).toLocaleDateString()
}
const shortTime = (date:Date)=>{
    let housr:String = new Date(date).getHours().toString()
    let minutes:String = new Date(date).getMinutes().toString()
    return `${housr}:${minutes}`
}

const TravelsCard = ({ ...props }: Props) => {
  const [images, setImages]= useState<IMedia[]>([]);
  travelsService.GetTravelById(props.travel.id).then(t=>setImages(t.data.media as IMedia[])).catch(err=>console.log(err))
  
  return (
    
    <div className="bg-slate-200 dark:bg-yellow-950 dark:text-white text-center m-4 p-4 rounded-md lg: w-{cardWidth}]">
      <GalereyList images={images}/>
      {/* <img src={images[0]?.physicalPath+images[0]?.name} width={cardWidth-4} height={cardWidth} alt={props.travel.media?.toString()}></img> */}
      <h3 className={"text-3xl m-4 p-4 overflow-x-hidden"}>{props.travel.description}</h3>
      <p><span>Дата отправления: </span>{shortDate(props.travel.startDate)}</p>
      <p><span>Время отправления: </span>{shortTime(props.travel.startDate)}</p>
      {}
    </div>
  );
};

export default TravelsCard;
