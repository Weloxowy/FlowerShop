import { Container, Text, Button, Group, MantineProvider } from '@mantine/core';
import { GithubIcon } from '@mantinex/dev-icons';
import classes from "./pages/Home.module.css";
import { HeaderMenu } from "./HeaderMenu";
import {useEffect} from "react";

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
        <MantineProvider>
            <div>
                <HeaderMenu />
                <div className={classes.wrapper}>
                    <Container size={700} className={classes.inner}>
                        <h1 className={classes.title}>
                            A{' '}
                            <Text component="span" variant="gradient" gradient={{ from: 'blue', to: 'cyan' }} inherit>
                                fully featured
                            </Text>{' '}
                            React components and hooks library
                        </h1>
                        <Text className={classes.description} color="dimmed">
                            Build fully functional accessible web applications with ease – Mantine includes more than
                            100 customizable components and hooks to cover you in any situation
                        </Text>
                        <Group className={classes.controls}>
                            <Button
                                size="xl"
                                className={classes.control}
                                variant="gradient"
                                gradient={{ from: 'blue', to: 'cyan' }}
                                onClick={handleGetStartedClick} // Add onClick event handler
                            >
                                Get started
                            </Button>
                            <Button
                                component="a"
                                href="https://github.com/mantinedev/mantine"
                                size="xl"
                                variant="default"
                                className={classes.control}
                                leftSection={<GithubIcon size={20} />}
                            >
                                GitHub
                            </Button>
                        </Group>
                    </Container>
                </div>
            </div>
        </MantineProvider>
    );
}
