import React from "react";
import { ITravel } from "../interfaces/app.interfaces";
import mediasService from "../services/medias.service";

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
  
  return (
    
    <div className="bg-slate-200 dark:bg-yellow-950 dark:text-white text-center m-4 p-4 rounded-md lg: w-{cardWidth}]">
      <img src={`/media/photo/${mediasService.GetTravelByTravelId(props.travel.id)[0]}`} width={cardWidth-4} height={cardWidth} alt={props.travel.media?.toString()}></img>
      <h3 className={"text-3xl m-4 p-4 overflow-x-hidden"}>{props.travel.description}</h3>
      <p><span>Дата отправления: </span>{shortDate(props.travel.startDate)}</p>
      <p><span>Время отправления: </span>{shortTime(props.travel.startDate)}</p>
    </div>
  );
};

export default TravelsCard;
