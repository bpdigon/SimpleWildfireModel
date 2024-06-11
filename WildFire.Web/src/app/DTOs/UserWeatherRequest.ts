import { LightningEvent } from "../models/LightningEvent";
import { RainEvent } from "../models/RainEvent";
import { WindEvent } from "../models/WindEvent";

export interface UserWeatherRequest{
    lightningEvent: LightningEvent;
    randomLightning: boolean;
    windEvent: WindEvent;
    randomWind: boolean;
    rainEvent: RainEvent;
    randomRain: boolean;
}