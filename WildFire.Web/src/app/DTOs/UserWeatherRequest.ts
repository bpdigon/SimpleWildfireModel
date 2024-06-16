import { LightningEvent } from "../models/LightningEvent";
import { RainEvent } from "../models/RainEvent";
import { WindEvent } from "../models/WindEvent";

export interface UserWeatherRequest{
    LightningEvent: LightningEvent;
    RandomLightning: boolean;
    WindEvent: WindEvent;
    RandomWind: boolean;
    RainEvent: RainEvent;
    RandomRain: boolean;
}