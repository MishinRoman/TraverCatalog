import axios from "axios"
import { IMedia, ITravel } from "../interfaces/app.interfaces"

class TravelSerivce {
   private URL = '/api/Medias'
    async GetTravels() {
        return await axios.get<IMedia[]>(this.URL)
    }
    async GetTravelById(id: string) {
        return axios.get<IMedia>(this.URL + id)
    }
    async GetTravelByTravelId(travelId: string) {
        return axios.get<IMedia[]>(this.URL + travelId)
    }
    async AddTravel(model: IMedia) {
        return (await axios.post<IMedia>(this.URL, model).catch(err=>console.log(err)))
    }
    async UpdateTravel(model: IMedia) {
        return axios.patch<IMedia>(this.URL, model)
    }
    async DeleteTravel(id: string) {
        return axios.delete(this.URL + id)
    }
}
export default new TravelSerivce()