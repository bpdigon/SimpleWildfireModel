import { LightningEvent } from "./LightningEvent";
import { RainEvent } from "./RainEvent";
import { WindEvent } from "./WindEvent";

export interface WeatherAudit{
    lightningEvents: Array<LightningEvent>;
    windEvents: Array<WindEvent>;
    rainEvents: Array<RainEvent>;
}