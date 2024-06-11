import { SimEnvironment } from "../models/SimEnvironment";
import { UserWeatherRequest } from "./UserWeatherRequest";

export interface SimulationRequest{
    environment: SimEnvironment;
    userWeather: UserWeatherRequest;
    turns?: number;
}