import { Direction } from "../enum/Direction.enum";

export interface WindEvent extends Event{
    Direction: Direction;
    WindSpeed: number;
}