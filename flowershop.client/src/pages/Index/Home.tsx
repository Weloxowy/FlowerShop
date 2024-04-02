import {Container, Text, Button, Group} from '@mantine/core';
import classes from "./Home.module.css";
import { HeaderMenu } from "../../layouts/Header/HeaderMenu";
import {useEffect} from "react";
import CarouselHome from "../../components/CarouselHome/CarouselHome";


export default function Home() {

    async function getCookies() {
        const response = await fetch("https://localhost:7142/api/AspNetUsers/info", {
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Credentials':'true'
            }

        });

        if (response.ok) {

            return true;
        } else {

            return false;
        }


    }
    useEffect(() => {
        const checkCookies = async () => {
            const isLoggedIn = await getCookies();
            if (isLoggedIn) {
                window.location.href = "/main";
            } else {

            }
        };
        checkCookies();
    }, []);
    const handleGetStartedClick = () => {
        window.location.href = "/pag";
    };

    return (
            <div>
                <div className={classes.header}>
                    <HeaderMenu />
                </div>
                <div>
                    <CarouselHome/>
                </div>
                <div>
                        <Group className={classes.controls}>
                            <Button
                                size="xl"
                                className={classes.control}
                                variant="filled"
                                onClick={handleGetStartedClick} // Add onClick event handler
                            >
                                Get started
                            </Button>
                        </Group>
                </div>
            </div>
    );
}
