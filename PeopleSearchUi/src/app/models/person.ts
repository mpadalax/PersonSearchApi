import { IInterest } from './interst';
import { IAddress } from './address';

export interface IPerson {
    PersonId?: number;
    FirstName: string;
    LastName: string;
    DateOfBirth: string;
    Picture: string;
    Age: number;
    Email: string;
    Addresses: IAddress[];
    Interests: IInterest[];
}