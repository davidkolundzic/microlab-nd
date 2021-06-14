export const IS_NOTIFIED = 1;
export const USER = {
  Id: 3,
  FirstName: "Giannis",
  LasName: "Blow",
  Email: "joe.blow@gmail.com",
  Company: "Microsoft",
  Title: "Developer",
};
export const REMAINDERS = {
  1: "1 Tag",
  2: "2 Tag",
  3: "3 Tag",
  4: "4 Tag",
  7: "1 Woche",
  14: "2 Woche",
};
export class Note {
    id : number = null;
  contactId: number = null;
  noteDate: Date = null;
  description: string = "";
  reminder: number = null;
  notified: number = 0;
}
