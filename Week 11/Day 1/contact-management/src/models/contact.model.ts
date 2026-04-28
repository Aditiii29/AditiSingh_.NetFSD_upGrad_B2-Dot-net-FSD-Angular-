// This is the blueprint/interface for every Contact object.
// export = other files can import and use this.

export interface Contact {
  contactId : number;    // auto-generated unique ID
  name      : string;    // full name
  email     : string;    // email address
  phone     : string;    // min 10 digits
  isActive  : boolean;   // true = Active, false = Inactive
}