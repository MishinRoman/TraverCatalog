import axios from "axios"
import { ITravel } from "../interfaces/app.interfaces"

class TravelSerivce {
    private URL = '/api/Travels'
    async GetTravelsCount() {
        return await axios.get<number>("/count")
    }
    async GetTravelsPage(page: number) {
        return await axios.get<ITravel[]>(this.URL + "?page=" + page)
    }
    async GetTravelById(id: string) {
        return axios.get<ITravel>(this.URL + "/id?id=" + id)
    }
    async AddTravel(model: ITravel) {
        return (await axios.post<ITravel>(this.URL, model).catch(err => console.log(err)))
    }
    async UpdateTravel(model: ITravel) {
        return axios.patch<ITravel>(this.URL, model)
    }
    async DeleteTravel(id: string) {
        return axios.delete(this.URL + id)
    }

}
export default new TravelSerivce()