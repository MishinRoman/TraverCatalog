import { IPhoto, ITravel } from "../interfaces/app.interfaces";

export const DefaultValue:ITravel={
    id:undefined,
    description:"",
    startDate: new Date(Date.now()),
    endDate:new Date(Date.now()),
    media:[],
    users:[],
    comments:[],
    price:0
}