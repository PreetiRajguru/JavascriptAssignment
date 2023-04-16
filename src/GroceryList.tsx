import * as React from 'react';
import { useState } from "react";
import Button from 'react-bootstrap/Button';
import './GroceryList.css';

interface GroceryItem {
    id: number;
    name: string;
}

const GroceryList = () => {
    const [groceryList, setGroceryList] = useState<GroceryItem[]>([]);
    const [inputValue, setInputValue] = useState<string>("");
    const [sortOrder, setSortOrder] = useState<"asc" | "desc">("asc");

    const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(event.target.value);
    };

    const handleAddItem = () => {

        if (inputValue.trim() === "") {
            return;
        }

        const newId = groceryList.length ? groceryList[groceryList.length - 1].id + 1 : 1;
        const newItem: GroceryItem = {
            id: newId,
            name: inputValue,
        };
        setGroceryList([...groceryList, newItem]);
        setInputValue("");
    };

    const handleRemoveItem = (id: number) => {
        const updatedList = groceryList.filter((item) => item.id !== id);
        setGroceryList(updatedList);
    };

    const handleSortList = () => {
        const sortedList = [...groceryList].sort((a, b) =>
            sortOrder === "asc" ? a.name.localeCompare(b.name) : b.name.localeCompare(a.name)
        );
        setGroceryList(sortedList);
        setSortOrder(sortOrder === "asc" ? "desc" : "asc");
    };

    return (
        <div>
            <header>
                <h1>Assignment - Grocery Items</h1><br></br>
            </header>
            <body>
                <div>
                    <br></br>
                    <input type="text" className='text-input' value={inputValue} onChange={handleInputChange} />
                </div>
                <div className='div-margin'>

                    <Button variant="success" onClick={handleAddItem}>Add Item</Button>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <Button className='sort-button' onClick={handleSortList}>
                        {sortOrder === "asc" ? "Sort A-Z" : "Sort Z-A"}
                    </Button>
                </div>
                <ul className='ul-style'>
                    <br></br>
                    {groceryList.map((item, index) => (
                        <li className='li-style' style={{ backgroundColor: index % 2 === 0 ? '#d9c9de' : '#99e7ee' }} key={item.id}>
                            <div className='li-div'>
                                <div>{item.name}</div>
                                <Button variant="danger" className='delete' onClick={() => handleRemoveItem(item.id)}>Delete</Button>
                            </div>
                        </li>
                    ))}
                </ul>

            </body>

        </div >
    );
};

export default GroceryList;