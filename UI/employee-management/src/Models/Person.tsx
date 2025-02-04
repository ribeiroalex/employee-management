import { Address } from "cluster";
import { Phone } from "./Phone";

export class Person {
    id: string = "";
    constructor(
        public firstName: string,
        public lastName: string,
        public documentNumber?: string,
        public password?: string,
        private phones: Phone[] = [],
        private addresses: Address[] = []
    ) {}
}