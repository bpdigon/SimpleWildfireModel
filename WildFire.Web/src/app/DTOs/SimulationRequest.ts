import { SimEnvironment } from "../models/SimEnvironment";
import { UserWeatherRequest } from "./UserWeatherRequest";

export interface SimulationRequest{
    Environment: SimEnvironment;
    UserWeather?: UserWeatherRequest;
    Turns?: number;
}