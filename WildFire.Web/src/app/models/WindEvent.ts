import { Direction } from "../enum/Direction.enum";

export interface WindEvent extends Event{
    direction: Direction;
    windSpeed: number;
}