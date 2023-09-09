import axios from "axios"
import { IMedia, ITraveForCreate, ITravel } from "../interfaces/app.interfaces"

class TravelSerivce {
   private URL = '/api/Travels'
    async GetTravels() {
        return await axios.get<ITravel[]>(this.URL)
    }
    async GetTravelById(id: string) {
        return axios.get<ITravel>(this.URL+"/id?id="+id)
    }
    async AddTravel(model: ITravel) {
        return (await axios.post<ITravel>(this.URL, model).catch(err=>console.log(err)))
    }
    async UpdateTravel(model: ITravel) {
        return axios.patch<ITravel>(this.URL, model)
    }
    async DeleteTravel(id: string) {
        return axios.delete(this.URL + id)
    }
}
export default new TravelSerivce()