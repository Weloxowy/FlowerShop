import { useToggle, upperFirst } from '@mantine/hooks';
import { useForm } from '@mantine/form';
import {
    TextInput,
    PasswordInput,
    Text,
    Paper,
    Group,
    PaperProps,
    Button,
    Divider,
    Checkbox,
    Anchor,
    Stack,
} from '@mantine/core';
import './App.css';
import '@mantine/core/styles.css';
import { MantineProvider } from '@mantine/core';
// @ts-ignore
import React, { useState, useEffect } from "react";
import {HeaderMenu} from "./HeaderMenu";
export default function App(props: PaperProps) {
    const [type, toggle] = useToggle(['login', 'register']);
    const form = useForm({
        initialValues: {
            email: '',
            name: '',
            password: '',
            terms: true,
        },

        validate: {
            email: (val) => (/^\S+@\S+$/.test(val) ? null : 'Invalid email'),
            password: (val) => (val.length <= 8 ? 'Password should include at least 8 characters' : null),
        },
    });
    async function handleRegister() {
        const url = "https://localhost:7142/api/UserEntity";
        const data = {
            Name: form.values.name,
            EmailAddress: form.values.email,
            Password: form.values.password,
            Login: "ziara", 
            TelephoneNumber: "123321123",
            Surname: "Ziara"

        }
        try {
            const response = await fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type':
                    'application/json',
                },
                body: JSON.stringify(data),
            });

            if (!response.ok) {
                const errorMessage = await response.text();
                throw new Error(`HTTP error! Status: ${response.status}, Message: ${errorMessage}`);
            }

            // Entity created successfully
            console.log('Entity created successfully');
        } catch (error) {
            console.error('Error creating entity:', error);
        }
    }
    const [users, setUsers] = useState([]);

    useEffect(() => {
        async function fetchData() {
            try {
                const response = await fetch("https://localhost:7142/api/UserEntity");
                //https://localhost:7142/api/UserEntity/users/login/[login]?password=[password]
                if (!response.ok) {
                    throw new Error("Failed to fetch data");
                }
                const data = await response.json();
                setUsers(data);
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        }

        fetchData();
    }, []);
    return <MantineProvider>{

        <Paper radius="md" p="xl" withBorder {...props}>
            <Text size="lg" fw={500}>
                Welcome to Mantine, {type} with
            </Text>
            <Divider label="Or continue with email" labelPosition="center" my="lg" />

            <form onSubmit={form.onSubmit(() => { })}>
                <Stack>
                    {type === 'register' && (
                        <TextInput
                            label="Imię i nazwisko"
                            placeholder="Imię i nazwisko"
                            value={form.values.name}
                            onChange={(event) => form.setFieldValue('name', event.currentTarget.value)}
                            radius="md"
                        />
                    )}

                    <TextInput
                        required
                        label="Email"
                        placeholder="hello@mantine.dev"
                        value={form.values.email}
                        onChange={(event) => form.setFieldValue('email', event.currentTarget.value)}
                        error={form.errors.email && 'Nieprawidłowy adres email'}
                        radius="md"
                    />

                    <PasswordInput
                        required
                        label="Hasło"
                        placeholder="Twoje hasło"
                        value={form.values.password}
                        onChange={(event) => form.setFieldValue('password', event.currentTarget.value)}
                        error={form.errors.password && 'Hasło powinno posiadać 8 znaków, w tym jedną dużą literę'}
                        radius="md"
                    />

                    {type === 'register' && (
                        <Checkbox
                            label="Akceptuje warunki serwisu."
                            checked={form.values.terms}
                            onChange={(event) => form.setFieldValue('terms', event.currentTarget.checked)}
                        />
                    )}
                </Stack>
                <Group justify="space-between" mt="xl">
                    <Anchor component="button" type="button" c="dimmed" onClick={() => toggle()} size="xs">
                        {type === 'register'
                            ? 'Posiadasz już konto? Zaloguj się'
                            : "Nie posiadasz konta? Zarejestruj się"}
                    </Anchor>
                    <Button type="submit" radius="xl" onClick={handleRegister}>
                        {upperFirst(type)}
                    </Button>
                </Group>
            </form>
            <Stack spacing="md">
                {users.map((user) => (
                    <div key={user.id}>
                        <Text>{user.name}</Text>
                        <Text>{user.surname}</Text>
                    </div>
                ))}
            </Stack>
        </Paper>
    }</MantineProvider>;
}