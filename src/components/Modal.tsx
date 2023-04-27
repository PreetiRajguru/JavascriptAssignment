import { Dialog, DialogContent, DialogTitle } from "@mui/material"
import { Customer } from "./Customers";

const Modal = ({customer, onClose}: {customer: Customer, onClose: () => void}) => {
    return (
        <Dialog open onClose={onClose}>
            <DialogTitle>Customer Data</DialogTitle>
            <DialogContent>
                <b>Name : </b>{customer.firstName}&nbsp;
                {customer.lastName}<br></br>
                <b>DOB : </b> {customer.dateOfBirth}<br></br>
                <b>Phone Number : </b> {customer.phoneNumber}<br></br>
                <b>Email : </b>{customer.email}<br></br>
                <b>Address : </b>{customer.address}<br></br>
            </DialogContent>
        </Dialog>
    )
}
export default Modal;