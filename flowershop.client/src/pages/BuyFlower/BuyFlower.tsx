import React from 'react';
import { HeaderMenu } from "../../layouts/Header/HeaderMenu";
import classes from "./BuyFlower.module.css";
import { Image } from '@mantine/core';
import flower from "../../../public/flower.jpg";
export default function BuyFlower() {
    return (
        <div>
            <div className={classes.header}>
                <HeaderMenu />
            </div>
            <div className = {classes.breadcrum}>
                <h2> Tutaj pojawi sie sciezka do pliku </h2>
            </div>
            <div className={classes.outerContainer}>
                <div className={classes.left}>
                    <Image
                    radius="md"
                    src={flower}
                    />
                </div>
                <div className={classes.right}>
                    <h4> Tutaj po prawej stronie beda informacje</h4>
                </div>
            </div>
            <div className={classes.recommend}>
                <h3>Polecane</h3>
            </div>
            <div className={classes.footer}>
                <h4> Stopka</h4>
            </div>

        </div>
    );
}
