import { Container, Text, Button, Group, MantineProvider } from '@mantine/core';
import { GithubIcon } from '@mantinex/dev-icons';
import classes from "./pages/Home.module.css";
import { HeaderMenu } from "./HeaderMenu";
import {useEffect, useState} from "react";

export default function MainPage() {
    const handleGetStartedClick = () => {
        window.location.href = "/pag";
    };

    async function getCookies() {
        const response = await fetch("https://localhost:7142/api/AspNetUsers/info", {
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Credentials':'true'
            }
            // mode: 'no-cors' - Przepusci zapytanie ale nie zwroci nic
        });
        const data = await response.json();
        console.log(data);
        return data.email;
    }

    const [email, setEmail] = useState('');

    useEffect(() => {
        getCookies().then(email => setEmail(email));
    }, []);

    return (
        <MantineProvider>
            <div>
                <HeaderMenu />
                <div className={classes.wrapper}>
                    <Container size={700} className={classes.inner}>
                        <h1 className={classes.title}>
                            {' '}
                            <Text component="span" variant="gradient" gradient={{ from: 'blue', to: 'cyan' }} inherit>
                                {email}
                            </Text>{' '}
                        </h1>

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
